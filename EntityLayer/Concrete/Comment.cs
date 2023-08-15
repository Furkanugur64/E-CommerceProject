using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment : IEntity
    {
        public int CommentID { get; set; }
        public DateTime CommentDate { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public bool Status { get; set; }
    }
}
