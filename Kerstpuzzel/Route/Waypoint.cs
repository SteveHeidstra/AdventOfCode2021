namespace Kerstpuzzel.Route
{
    public class Waypoint
    {
        public Waypoint(Node node)
        {
            Reference = node.Reference;

            if ( node.shortestLeg != null)
            {
                From = new Waypoint(node.shortestLeg.Start);
            }
        }

        public object Reference { get;  private set; }
        public Waypoint From { get; set; }
        public Waypoint To { get; set; }
    }
}
