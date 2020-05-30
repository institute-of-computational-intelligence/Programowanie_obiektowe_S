using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    abstract class Position
    {
        protected string title;
        protected int id;
        protected string publishingHouse;
        protected DateTime publicationDate;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }

        public Position()
        {
            title = "unknown";
            id = 0;
            publishingHouse = "unknown";
            publicationDate = new DateTime();
        }

        public Position(string title_,int id_,string publishingHouse_,DateTime publicationDate_)
        {
            title = title_;
            id = id_;
            publishingHouse = publishingHouse_;
            publicationDate = publicationDate_;
        }

        public override string ToString()
        {
            return $"Title:  {title} Id: {id} Publishing house: {publishingHouse} Publication date {publicationDate}";
        }

        public abstract void Details();

    }
}
