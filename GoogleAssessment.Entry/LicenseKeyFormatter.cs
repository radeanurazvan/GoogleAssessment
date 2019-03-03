using System.Linq;

namespace GoogleAssessment.Entry
{
    public static class LicenseKeyFormatter
    {
        private const string DASH = "-";

        public static string Format(string subject, int chunkSize)
        {
            var uppercaseSubject = subject.ToUpper();
            var strippedSubject = uppercaseSubject.Replace("-", string.Empty);

            var firstGroupLength = strippedSubject.Length % chunkSize;
            if (firstGroupLength == 0)
            {
                firstGroupLength = chunkSize;
            }

            var firstGroup = string.Concat(strippedSubject.Where((c, i) => i < firstGroupLength));
            var notFirstGroups = string.Concat(strippedSubject.Where((c, i) => i >= firstGroupLength));

            var chunks = Enumerable.Range(0, notFirstGroups.Length / chunkSize)
                .Select(i => notFirstGroups.Substring(i * chunkSize, chunkSize))
                .ToList();
            chunks.Insert(0, firstGroup);

            return string.Join(DASH, chunks);
        }
    }
}