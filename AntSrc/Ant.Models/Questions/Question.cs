using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;

namespace Ant.Models.Questions
{
    public class Question
    {

        // 题目数据：
        // 1. 编号
        // 2. 内容
        // 3. 问题
        // 4. 五个选项
        // 5. 解答
        // 6. 正确选项
        // 7. 评论
        // 8. 来源：GWD
        // 9. 类型：SC
        // 10. 价值：1-5 Rate
        // 11. 统计数据：用户选择的答案
        // 12. 创建时间
        // 13. (摘要)
        // 14. (创建人) 
        public ObjectId _id { set; get; }
        public EntityInfo Info;

        public Int32 Number { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string Ask { get; set; }
        public string Options { get; set; }
    }
}
