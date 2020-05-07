namespace Lab8
{
    public class Grade
    {
        public string Subject { get; set; }
        public double Value { get; set; }

        public Grade(string subject, double value)
        {
            Subject = subject;
            Value = value;
        }
    }
}
