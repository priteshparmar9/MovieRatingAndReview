using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRatingAndReview.Models;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors;

namespace MovieRatingAndReview.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response>> Login(Users user)
        {
            Users? users = _context.Users.SingleOrDefault(u => u.UserName == user.UserName);
            if(users == null)
            {
                users = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            }

            if (users == null)
            {
                return NotFound();
            }

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(users.Password);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);

            Response res = new Models.Response();
            if (user.Password == result)
            {
                res.StatusCode = 201;
                res.Message = "Login Successful";
            }
            else
            {
                res.StatusCode = 500;
                res.Message = "Invalid Credentials";
            }
            return res;
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("signup")]
        public async Task<ActionResult<Response>> PostUsers(Users users)
        {
            Users? user = _context.Users.SingleOrDefault(u => u.UserName == users.UserName || u.Email == users.Email);
            if(user != null)
            {
                Response res1 = new Response();
                res1.Message = "User already registered!";
                res1.StatusCode = 201;
                return res1;

            }

            byte[] encData_byte = new byte[users.Password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(users.Password);
            users.Password = Convert.ToBase64String(encData_byte);


            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            Response res = new Response();
            res.Message = "User Registered";
            res.StatusCode = 200;
            return res;
        }

        // DELETE: api/Users/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
