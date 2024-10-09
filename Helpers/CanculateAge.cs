namespace OsonAptekaFastEndpoints.Helpers
{
    public static class CanculateAge
    {
        public static int Calculate(this DateTime dob)
        {
            var today = DateTime.UtcNow.Date;
            var age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
