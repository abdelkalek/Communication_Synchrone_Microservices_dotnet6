using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Role.DataContext;

namespace Role.Controllers
{
    public class RolesController : Controller
    {


        protected  RoleContext _contextRole;

        public RolesController(RoleContext contextRole)
        {
            _contextRole = contextRole;
        }
        private int _nextId = 1;

        // POST api/<RolesController>
        [HttpPost("PostRole")]
        public  Model.Role Post([FromBody] Model.Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");

            }
            //role.Id = _nextId++;
             this._contextRole.Add(role);
            _contextRole.SaveChangesAsync();

            return role;

        }


        // GET: api/<UsersController>

        [HttpGet("GetListRole")]
        public List<Model.Role> GetList()
        {
            return this._contextRole.Roles.ToList();
        }
        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public Model.Role Get(Guid id)
        {
            return this._contextRole.Roles.FirstOrDefault(r => r.id.Equals(id));

        }

   
        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public   async Task<IActionResult>  Put(Guid id, [FromBody] Model.Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            var isRole = this._contextRole.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.id.Equals( id));
            if (isRole == null)
            {
                return BadRequest();
            }
             _contextRole.Entry(role).State = EntityState.Modified;
            await _contextRole.SaveChangesAsync();
          return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var role = this._contextRole.Roles.FirstOrDefault(r => r.id.Equals(id));
            if(role == null)
            {
                throw new ArgumentNullException("role");

            }
            _contextRole.Set<Model.Role>().Remove(role);
             _contextRole.SaveChangesAsync();
        }
    }
}
