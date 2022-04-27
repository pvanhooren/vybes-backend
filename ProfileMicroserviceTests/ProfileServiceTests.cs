using System;
using System.Collections.Generic;
using System.Globalization;
using Moq;
using ProfileMicroservice;
using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.Services;
using ProfileMicroservice.Services.Interfaces;
using Xunit;

namespace ProfileMicroserviceTests;

public class ProfileServiceTests
{
    private Mock<IProfileRepository> _profileRepository;
    private IProfileService _profileService;

    [Fact]
    public void GetProfilesTest()
    {
        // Arrange
        _profileRepository = new Mock<IProfileRepository>();

        var profiles = new List<Profile>();

        profiles.Add(
            new Profile
            {
                UserId = "google-oauth2|114384940923729557604",
                DisplayName = "Pim",
                About = "Hi my name is Pim",
                PhoneNumber = "06-12345678",
                Birthday = DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        
        profiles.Add(
            new Profile
            {
                UserId = "google-oauth2|114384940923729227604",
                DisplayName = "Alex",
                About = "Hi my name is Alex and I like to play football",
                PhoneNumber = "06-87654321",
                Birthday = DateTime.ParseExact("2002-04-18 16:30", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

        _profileRepository.Setup(repo => repo.GetProfiles()).Returns(profiles);

        _profileService = new ProfileService(_profileRepository.Object);

        // Act
        var result = _profileService.GetProfiles();

        // Assert
        Assert.Equal(2, result.Count);
    }
}