using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ant.Models
{
    public class Paging
    {
        public Paging()
        {
            p = 1;
            count = 20;
        }

        // 请求页数
        public int? p { get; set; }
        // 每页数量
        public int? count { get; set; }

        public IQueryable<T> Page<T>(IQueryable<T> query)
        {
            return query.Skip(this.Skip).Take(this.Take);
        }

        public int Skip
        {
            get
            {
                return (p.Value-1) * count.Value;
            }
        }

        public int Take
        {
            get
            {
                return count.Value;
            }
        }
    }
}