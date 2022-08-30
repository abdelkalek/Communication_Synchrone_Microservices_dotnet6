using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using User.DataContext;
using User.Model;
using User.Model.Dtos;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected UserContext _contextUser;
        protected   RoleCommunication _roleCommunication;
        public UsersController(UserContext contextUser)
        {
            _contextUser = contextUser;
        }
        [HttpGet("GetListRoles")]
        public async Task<List<RoleDto>> GetListRoles()
        {
            RoleCommunication roleCo = new RoleCommunication();
            return await roleCo.getListRole();

        }

        // POST api/<UsersController>
        [HttpPost("PostUser")]
        public async Task<Model.User> PostAsync([FromBody] UserDto User)
        {
            if (User == null)
            {
                throw new ArgumentNullException("User");

            }
            var us = new Model.User
            {
                id = User.id,
                Nom = User.Nom,
                Prenom = User.Prenom

            };

            RoleCommunication roleCo = new RoleCommunication();
            List<RoleDto> roles = await roleCo.getListRole();
         
                var role = roles.Find(r => r.id.Equals(User.roleId));
            var r = new Role
            {
                id = role.id,
                Nom = role.Nom,
             };
         var res = _contextUser.Roles.Add(r);
           if(res.Entity != null)
            {
                us.Role = res.Entity;
                us.RoleID = us.Role.id;
            }

          _contextUser.Add(us);
            _contextUser.SaveChangesAsync();

            return us;

        }


        // GET: api/<UsersController>

        [HttpGet("GetListUser")]
        public List<Model.User> GetList()
        {
            return this._contextUser.Users.ToList();
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Model.User Get(Guid id)
        {
            return this._contextUser.Users.Include(x => x.Role).FirstOrDefault(r => r.id.Equals(id));

        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Model.User User)
        {
            if (User == null)
            {
                throw new ArgumentNullException("User");
            }
            var isUser = this._contextUser.Users.AsNoTracking().FirstOrDefaultAsync(x => x.id.Equals( id));
            if (isUser == null)
            {
                return BadRequest();
            }
            _contextUser.Entry(User).State = EntityState.Modified;
            await _contextUser.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var User = this._contextUser.Users.FirstOrDefault(r => r.id.Equals( id));
            if (User == null)
            {
                throw new ArgumentNullException("User");

            }
            _contextUser.Set<Model.User>().Remove(User);
            _contextUser.SaveChangesAsync();
        }
    }
}
