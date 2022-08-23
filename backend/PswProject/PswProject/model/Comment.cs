using System;

namespace PswProject.model
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime TimeWritten { get; set; }
        public String Content { get; set; }
        public String Name { get; set; }
        public Boolean canPublish { get; set; }

        public Comment() { }
        public Comment(int id, DateTime date, string context, string name, Boolean canPublish)
        {
            Id = id;
            TimeWritten = date;
            Name = name;
            Content = context;
            this.canPublish = canPublish;
            Validate();
        }

        public Comment(DateTime time, string content, string name, bool v)
        {
            TimeWritten = time;
            Content = content;
            Name = name;
            canPublish = v;
            Validate();
        }
        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));

        }
    }
}
