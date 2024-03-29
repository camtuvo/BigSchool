﻿using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
   
    public class FollowingsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Follow (Following follow)
        {
            var userID = User.Identity.GetUserId();
            if (userID == null)
                return BadRequest("Please login first!");
            if (userID == follow.FolloweeId)
                return BadRequest("Cant follow myself!");
            DatabaseContext cx = new DatabaseContext();
            //kiem tra
            Following find = cx.Followings.FirstOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId);
            if (find != null)
            {
                // return BadRequest("The already following exists!");
                cx.Followings.Remove(cx.Followings.SingleOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId));
                cx.SaveChanges();
                return Ok("cancel");
            }
            follow.FollowerId = userID;
            cx.Followings.Add(follow);
            cx.SaveChanges();
            return Ok();
        }
    }
}
