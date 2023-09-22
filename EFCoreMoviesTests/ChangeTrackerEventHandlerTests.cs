using EFCoreMovies.Utilities;
using EFCoreMoviesTests.Mocks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMoviesTests
{
    [TestClass]
    public class ChangeTrackerEventHandlerTests
    {
        [TestMethod]
        public void SavedChangesHandler_Send3AsAmountOfEntries_LogsCorrectMessage()
        {
            //Preparation
            var loggerFake = new LoggerFake<ChangeTrackerEventHandler>();
            var changeTrackerEventHandler = new ChangeTrackerEventHandler(loggerFake);

            //Testing
            var savedChangesEventArgs = new SavedChangesEventArgs(
                acceptAllChangesOnSuccess: false,
                entitiesSavedCount: 3);
            changeTrackerEventHandler.SavedChangesHandler(null, savedChangesEventArgs);

            //Verification
            Assert.AreEqual("We processed 3 entities.", loggerFake.LastLog);
            Assert.AreEqual(1, loggerFake.CountLogs);
        }
    }
}