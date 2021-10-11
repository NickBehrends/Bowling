using System.Collections.Generic;

namespace Bowling.Tests.Application
{
    public static class ParameterProvider
    {
        public static IEnumerable<object[]> InvalidLaneCreation =>
            new List<object[]>
            {
                new object[] { null, null},
                new object[] { GetValidGameName(), null},
                new object[] { null, GetValidPlayerParameter()},
                new object[] { "", GetValidPlayerParameter()},
                new object[] { " ", GetValidPlayerParameter() },
                new object[] { GetValidGameName(), new List<string>() },
                new object[] { GetValidGameName(), new List<string> { "", " ", null } },
            };

        private static ICollection<string> GetValidPlayerParameter()
        {
            return new List<string>
            {
                "Nick"
            };
        }

        private static string GetValidGameName()
        {
            return "Proper Name";
        }
    }
}