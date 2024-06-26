using GestionLab.BLL.Contrato;
using GestionLab.BLL.ServiciosTareas.Contrato;
using GestionLab.DTO;
using GestionLab.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.BLL.ServiciosTareas
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly string secretKey;
        private readonly string hash;
        public LoginService(IUsuarioService usuarioService, IConfiguration config) 
        {
            secretKey = config["settings:secretKey"];
            hash = config["settings:hash"];
            _usuarioService = usuarioService;
        }
        public async Task<ResponseLogin> Login(LoginDTO user)
        {
            try
            {
                List<UsuarioDTO> listaUsuarios = await _usuarioService.ListarUsuarios();
                IEnumerable<UsuarioDTO> usuariosEncontrado = listaUsuarios.Where(u => u.Correo == user.Email);
                foreach(UsuarioDTO usuario in usuariosEncontrado)
                {
                    try
                    {
                        var contrasenaDesncript = this.Decrypy(usuario.Contrasena);
                        if (user.Contrasena == contrasenaDesncript)
                        {
                            var token = this.GenerateToken(usuario);
                            ResponseLogin response = new ResponseLogin
                            {
                                token = token,
                                user = usuario
                            };
                            return response;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                throw new TaskCanceledException("Usuario no encontrado");
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Register(UsuarioDTO usuario)
        {
            try
            {
                usuario.Contrasena = this.Encrypt(usuario.Contrasena);
                var usuarioCreado = await _usuarioService.CrearUsuario(usuario);
                return usuarioCreado;
            }
            catch
            {
                throw;
            }
        }


        private string Encrypt(string mensaje)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(mensaje);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);

        }

        private string Decrypy(string mensajeEncriptado)
        {
            byte[] data = Convert.FromBase64String(mensajeEncriptado);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }

        private string GenerateToken(UsuarioDTO usuario)
        {
            try
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaims(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Correo),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("id", usuario.IdUsuario.ToString()),
                    new Claim("idRol", usuario.IdRol.ToString()),
                    new Claim("idSucursal", usuario.IdSucursal.ToString()),
                    new Claim("idTipoIdentificacion", usuario.IdTipoIdentificacion.ToString()),
                    new Claim("numeroIdentificacion", usuario.NumeroIdentificacion.ToString()),
                    new Claim("correo", usuario.Correo.ToString()),
                    new Claim("urlFoto", usuario.UrlFoto.ToString()),
                    new Claim("estado", usuario.Estado.ToString()),
                    new Claim("createdAt", usuario.CreatedAt.ToString()),
                    new Claim("updatedAt", usuario.UpdateAt.ToString())
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return tokenCreado;
            }
            catch
            {
                throw;
            }
        }
    }
}
