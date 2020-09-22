﻿using LokwaInnovation.DBContext;
using LokwaInnovation.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LokwaInnovation
{
    public class TokenProvider
    {
        ApplicationDBContext _context;

        public TokenProvider(ApplicationDBContext context)
        {
            _context = context;
        }
        public string LoginUser(string phone, string password, string isvarifiead)
        {
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(password);
            string encodedTxt = Convert.ToBase64String(encodedBytes);

            //string username = strEmail;
            string pass = encodedTxt;
            string varified = isvarifiead;
            //&& x.IsVarified== "true"
            var user = _context.Log_in.SingleOrDefault(x => x.Phone_number == phone && x.Password == pass);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return null;

            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            var JWToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            var strusername = user.Email;
            return token;
        }
        private IEnumerable<Claim> GetUserClaims(Log_in user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Email, user.Email);
            claims.Add(_claim);
            //_claim = new Claim(ClaimTypes.NameIdentifier, user.strUserId);
            //claims.Add(_claim);
            //_claim = new Claim("EMAILID", user.strEmail);
            //claims.Add(_claim);
            //_claim = new Claim("PHONE", user.strPhone);
            //claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Name, user.Full_name);
            claims.Add(_claim);

            //if (user.Role != "")
            //{
            //    _claim = new Claim(user.Role, user.Role);
            //    claims.Add(_claim);
            //}
            return claims.AsEnumerable<Claim>();
        }
    }
}