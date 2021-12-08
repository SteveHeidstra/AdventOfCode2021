namespace Kerstpuzzel.Route
{
    public class Leg
    {
        public Leg(Node start, Node end, double lenght)
        {
            Start = start;
            End = end;
            Length = lenght;
            start.Neighbours.Add(end);
            end.Neighbours.Add(start);
        }

        public Node Start { get; set; }
        public Node End { get; set; }
        public double Length { get; set; }

        public bool Contains(Node node)
        {
            return Start == node || End == node;
        }
    }
}
