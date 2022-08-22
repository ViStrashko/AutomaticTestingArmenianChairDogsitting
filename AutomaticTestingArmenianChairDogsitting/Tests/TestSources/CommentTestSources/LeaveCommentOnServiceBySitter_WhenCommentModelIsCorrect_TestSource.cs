using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.CommentTestSources
{
    public class LeaveCommentOnServiceBySitter_WhenCommentModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new CommentRegistrationRequestModel()
            {
                Rating = 5,
                Text = "Хозяин вежливый, собака классная.",
            };
        }
    }
}
