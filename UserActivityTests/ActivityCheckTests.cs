using Moq;
using UserActivity;

namespace UserActivityTests
{
    public class ActivityCheckTests
    {
        [Fact]
        public async Task IsInactive_1mpPassed_Inactive()
        {
            var m = new Mock<ITimeProvider>();
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 0, 0));
            var a = new ActivityCheck(1, m.Object);
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 1, 10));

            await Task.Delay(10).WaitAsync(new TimeSpan(0, 5, 0));

            Assert.True(a.IsInactive(), "A user 5mp után még aktív");
        }

        [Fact]
        public async Task IsInactive_ActivityHappened_IsActive()
        {
            var m = new Mock<ITimeProvider>();
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 0, 0));
            var a = new ActivityCheck(1, m.Object);
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 1, 10));

            a.ActivityHappened();
            await Task.Delay(10).WaitAsync(new TimeSpan(0, 5, 0));

            Assert.False(a.IsInactive(), "A user aktivitást végzett mégis inaktív");
        }


        [Fact]
        public async Task IsInactive_ActivityHappenedAfter200ms_IsActiveAfter1sec()
        {
            var m = new Mock<ITimeProvider>();
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 0, 0));
            var a = new ActivityCheck(1, m.Object);
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 0, 200));

            a.ActivityHappened();
            m.Setup(x => x.GetNow()).Returns(new DateTime(2024, 02, 28, 0, 0, 1, 10));

            await Task.Delay(10).WaitAsync(new TimeSpan(0, 5, 0));

            Assert.False(a.IsInactive(), "A user aktivitást végzett mégis inaktív");
        }
    }
}