using System;
using System.Collections.Generic;
using System.Text;

namespace Zad03 {
    abstract class Position {
        protected string title;
        protected int id;
        protected string publisher;
        protected DateTime releaseDate;

        public string Title { get => title; set => title = value; }
        public int Id { get => id; set => id = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }

        public Position() {
            title = "null";
            id = 0;
            publisher = "null";
            releaseDate = new DateTime();
        }
        public Position(string title, int id, string publisher, DateTime releaseDate) {
            this.title = title;
            this.id = id;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
        }
        public override string ToString() {
            return $"Title: {title}, ID: {id}, Publisher: {publisher}, Release date: {releaseDate.ToString("dd/MM/yyyy")}";
        }
        public abstract void Details();
    }
}
