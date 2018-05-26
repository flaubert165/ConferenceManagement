using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Entities.Factories;
using Moq;

namespace ConferenceManagement.Domain.Tests.Entities
{
    [TestClass]
    public class ConferenceTests
    {
        [TestMethod]
        public void TestCreateNewTrack()
        {
            var factoryMock = new Mock<ITrackFactory>();
            BaseTrack track = new TrackTwoSessions("Track 1");

            factoryMock.Setup(factory => factory.CreateTrack("Track 1")).Returns(track);
            Conference conference = new Conference(factoryMock.Object);

            conference.CreateNewTrack();

            factoryMock.VerifyAll();
        }
        
    }
}
