namespace ElevatorApi.Models
{
    public class Floor(int number)
    {
        /// <summary>
        /// The number of the floor
        /// </summary>
        public int Number { get; set; } = number;
    }

}
