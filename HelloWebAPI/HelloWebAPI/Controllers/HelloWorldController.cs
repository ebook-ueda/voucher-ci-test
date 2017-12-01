using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HelloWebAPI.Entities;

namespace HelloWebAPI.Controllers
{
    public class HelloWorldController : ApiController
    {
        private HelloWorldModel db = new HelloWorldModel();

        public IEnumerable<MyWorlds> Get()
        {
            return db.MyWorlds;
        }

        [ResponseType(typeof(MyWorlds))]
        public MyWorlds Get(int id)
        {
            return db.MyWorlds.Find(id);
        }

        [ResponseType(typeof(MyWorlds))]
        public IHttpActionResult Post([FromBody]MyWorlds myCity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 
            db.MyWorlds.Add(myCity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { count = db.MyWorlds.Count() }, db.MyWorlds);
        }

        [ResponseType(typeof(MyWorlds))]
        public IHttpActionResult Post([FromBody]List<MyWorlds> myWorlds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 
            foreach (var myEntity in myWorlds)
            {
                db.MyWorlds.Add(myEntity);
            }
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { count = myWorlds.Count }, myWorlds);
        }

    }
}
