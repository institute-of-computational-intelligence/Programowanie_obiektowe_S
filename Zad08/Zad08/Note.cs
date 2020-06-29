namespace Zad08 {
    public class Note {
        private double grade;
        private string date;
        private string subject;

        public double Grade { get => grade; set => grade = value; }
        public string Date { get => date; set => date = value; }
        public string Subject { get => subject; set => subject = value; }

        public Note() { }

        public Note(double grade, string date, string subject) {
            this.grade = grade;
            this.date = date;
            this.subject = subject;
        }


        public override string ToString() {
            return $"Ocena: {grade}, Data: {date}, Przedmiot: {subject}";
        }

    }
}
