using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzer
    {
        public List<string> Play(int target, List<FizzBuzzMatch> matches)
        {
            List<string> responses = new List<string>();

            if (matches != null)
            {
                //matches.Sort((x, y) => x.Divisor.CompareTo(y.Divisor));

                for (int i = 1; i <= target; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var match in matches)
                    {
                        sb.Append(i%match.Divisor == 0 ? match.Response : "");
                    }

                    if (sb.Length == 0)
                        sb.Append(i.ToString());

                    responses.Add(sb.ToString());
                }
            }
            return responses;
        }
    }
}