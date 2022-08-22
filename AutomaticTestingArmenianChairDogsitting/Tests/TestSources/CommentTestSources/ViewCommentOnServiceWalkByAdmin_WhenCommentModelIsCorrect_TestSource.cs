using AutomaticTestingArmenianChairDogsitting.Models.Request;
using System.Collections;

namespace AutomaticTestingArmenianChairDogsitting.Tests.TestSources.CommentTestSources
{
    public class ViewCommentOnServiceWalkByAdmin_WhenCommentModelIsCorrect_TestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CommentRegistrationRequestModel()
                {
                    Rating = 5,
                    Text = "Собачка была под хорошим присмотром, и я не порвала себе сердце от беспокойства за неё.",
                },
                new CommentRegistrationRequestModel()
                {
                    Rating = 5,
                    Text = "Хозяин вежливый, собака классная.",
                }
            };
        }
    }
}
