using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface ICommentService
    {
        List<Comment> GetComments();
        Comment GetComment(int id);
        List<Comment> GetCommentByUserId(int userid);
        List<Comment> GetCommentByEventId(int eventid);
        bool AddComment(Comment newActivity);
    }
}
