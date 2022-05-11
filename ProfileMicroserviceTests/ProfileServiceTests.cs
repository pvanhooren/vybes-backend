using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProfileMicroservice;
using ProfileMicroservice.Data;
using ProfileMicroservice.Data.Repositories;
using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.Services;
using ProfileMicroservice.Services.Interfaces;
using Xunit;

namespace ProfileMicroserviceTests;

public class ProfileServiceTests
{
    private ProfileService _profileService;

    public void CreateDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "ProfileTestDb")
            .EnableSensitiveDataLogging()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .Options;

        var dbContext = new AppDbContext(options);

        if (dbContext.Profiles.Count() <= 0)
        {
            var profile1 = new Profile
            {
                UserId = "google-oauth2|114384940923729557604",
                UserName = "pimv_h",
                DisplayName = "Pim",
                About = "Hi my name is Pim",
                PhoneNumber = "06-12345678",
                Birthday = DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var profile2 = new Profile
            {
                UserId = "google-oauth2|114384940923729227604",
                UserName = "AlexVonCleef",
                DisplayName = "Alex",
                About = "Hi my name is Alex and I like to play football",
                PhoneNumber = "06-87654321",
                Birthday = DateTime.ParseExact("2002-04-18 16:30", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var profile3 = new Profile
            {
                UserId = "google-oauth2|114384941823729227604",
                UserName = "alexiaorange",
                DisplayName = "Alexia van Oranje",
                About = "Hello dear friends, my name is Alexia van Oranje and I am a princess in the Netherlands!",
                PhoneNumber = "0100-0200",
                Birthday = DateTime.ParseExact("2005-06-26 12:00", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            var profile4 = new Profile
            {
                UserId = "google-oauth2|114384941823729227604",
                UserName = "borisje",
                DisplayName = "Boris",
                About = "Ik ga stoppen met Vybes, ontvriend iedereen!",
                PhoneNumber = "0100-0200",
                Birthday = DateTime.ParseExact("1996-04-13 00:30", "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            dbContext.Profiles.Add(profile1);
            dbContext.Profiles.Add(profile2);
            dbContext.Profiles.Add(profile3);
            dbContext.Profiles.Add(profile4);

            dbContext.SaveChanges();
        }

        var profileRepository = new ProfileRepository(dbContext);
        _profileService = new ProfileService(profileRepository);
    }
    
    [Fact]
    public void A_GetProfilesTest()
    {
        // Arrange
        CreateDb();

        // Act
        var result = _profileService.GetProfiles();

        // Assert
        Assert.Equal(4, result.Count);
    }
    
    [Fact]
    public void GetProfileByIdTest()
    {
        // Arrange
        CreateDb();
        
        var id = 1;

        // Act
        var result = _profileService.GetProfileById(id);

        // Assert
        Assert.Equal(DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
            CultureInfo.InvariantCulture), result!.Birthday);
    }
    
    [Fact]
    public void GetProfileByIdTest_FailByInvalidProfileId()
    {
        // Arrange
        CreateDb();
        
        var id = 10;  // This profile id does not exist, so no profile should be found!

        // Act
        var result = _profileService.GetProfileById(id);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void GetProfileByIdTest_FailByEmptyProfileId()
    {
        // Arrange
        CreateDb();
        
        var id = 0;  // This profile id is zero, so no profile should be found!

        // Act
        var result = _profileService.GetProfileById(id);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void GetProfileByUserIdTest()
    {
        // Arrange
        CreateDb();
        
        var userId = "google-oauth2|114384940923729227604";

        // Act
        var result = _profileService.GetProfileByUserId(userId);

        // Assert
        Assert.Equal("Hi my name is Alex and I like to play football", result!.About);
    }
    
    [Fact]
    public void GetProfileByUserIdTest_FailByInvalidUserId()
    {
        // Arrange
        CreateDb();
        
        var userId = "google-oauth2|114382940923729227601"; // This user id does not exist, so no profile should be found!

        // Act
        var result = _profileService.GetProfileByUserId(userId);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void GetProfileByUserIdTest_FailByEmptyUserId()
    {
        // Arrange
        CreateDb();
        
        var userId = ""; // This user id is empty, so no profile should be found!

        // Act
        var result = _profileService.GetProfileByUserId(userId);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void GetProfileByUserNameTest()
    {
        // Arrange
        CreateDb();
        
        var userName = "alexiaorange";

        // Act
        var result = _profileService.GetProfileByUserName(userName);

        // Assert
        Assert.Equal("0100-0200", result!.PhoneNumber);
    }
    
    [Fact]
    public void GetProfileByUserNameTest_FailByInvalidUserName()
    {
        // Arrange
        CreateDb();
        
        var userName = "alexiavonorange"; // This username does not exist, so no profile should be found!

        // Act
        var result = _profileService.GetProfileByUserName(userName);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void GetProfileByUserNameTest_FailByEmptyUserName()
    {
        // Arrange
        CreateDb();
        
        var userName = ""; // This user id is empty, so no profile should be found!

        // Act
        var result = _profileService.GetProfileByUserName(userName);

        // Assert
        Assert.Null(result!);
    }

    [Fact]
    public void AddProfileTest()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            UserId = "google-oauth2|114114941823729227604",
            UserName = "hallo_antoon",
            DisplayName = "Antoon",
            About = "Bekende Nederlandstalige zanger van o.a. de nummers Hotelschool en Hallo",
            PhoneNumber = "06-11223344",
            Birthday = DateTime.ParseExact("2002-02-11 23:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.AddProfile(profile);

        // Assert
        Assert.Equal("06-11223344", result!.PhoneNumber);
    }
    
    [Fact]
    public void AddProfileTest_FailByDuplicateProfileId()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            ProfileId = 2, // This profile id already exists for another profile, so this profile should not be created!
            UserId = "google-oauth2|114384941442729227604",
            UserName = "queen_maxima",
            DisplayName = "Maxima",
            About = "Goedendag iedereen, welkom op mijn profiel.",
            PhoneNumber = "06-11223344",
            Birthday = DateTime.ParseExact("1979-05-17 06:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var ex = Assert.Throws<ArgumentException>(() => _profileService.AddProfile(profile));

        // Assert
        Assert.Equal("An item with the same key has already been added. Key: 2", ex.Message);
    }
    
    [Fact]
    public void AddProfileTest_FailByDuplicateUserName()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            UserId = "google-oauth2|114384941442729227604",
            UserName = "alexiaorange", // This username already exists for another profile, so this profile should not be created!
            DisplayName = "Maxima",
            About = "Goedendag iedereen, welkom op mijn profiel.",
            PhoneNumber = "06-11223344",
            Birthday = DateTime.ParseExact("2002-02-11 23:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.AddProfile(profile);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void AddProfileTest_FailByDuplicateUserId()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            UserId = "google-oauth2|114384941823729227604", // This user id already exists for another profile, so this profile should not be created!
            UserName = "queen_maxima",
            DisplayName = "Maxima",
            About = "Goedendag iedereen, welkom op mijn profiel.",
            PhoneNumber = "06-11223344",
            Birthday = DateTime.ParseExact("2002-02-11 23:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.AddProfile(profile);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void UpdateProfileTest()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            ProfileId = 1,
            UserId = "google-oauth2|114384940923729557604",
            UserName = "pimv_h",
            DisplayName = "Pim van Hooren", // This value is being changed
            About = "Hi my name is Pim",
            PhoneNumber = "06-12345678",
            Birthday = DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.UpdateProfile(profile);

        // Assert
        Assert.Equal("Pim van Hooren", result!.DisplayName);
    }
    
    [Fact]
    public void UpdateProfileTest_UpdateUserName()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            ProfileId = 2,
            UserId = "google-oauth2|114384940923729227604",
            UserName = "Alex_von_cleef", // The username of this profile is changed, so it should pass through an extra check.
            DisplayName = "Alex",
            About = "Hi my name is Alex and I like to play football",
            PhoneNumber = "06-87654321",
            Birthday = DateTime.ParseExact("2002-04-18 16:30", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.UpdateProfile(profile);

        // Assert
        Assert.Equal("Alex_von_cleef", result!.UserName);
    }
    
    [Fact]
    public void UpdateProfileTest_FailByDuplicateUserName()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            ProfileId = 3,
            UserId = "google-oauth2|114384941823729227604",
            UserName = "pimv_h", // This username already exists for another profile, so this profile should not be updated!
            DisplayName = "Alexia van Oranje",
            About = "Hello dear friends, my name is Alexia van Oranje and I am a princess in the Netherlands!",
            PhoneNumber = "0100-0200",
            Birthday = DateTime.ParseExact("2005-06-26 12:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.UpdateProfile(profile);

        // Assert
        Assert.Null(result!);
    }
    
    [Fact]
    public void UpdateProfileTest_FailByInvalidProfileId()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile()
        {
            ProfileId = 10, // This profile id does not exist, so this profile should not be updated!
            UserId = "google-oauth2|114384941823729227604",
            UserName = "alexiaorange", 
            DisplayName = "Alexia van Oranje",
            About = "Hello dear friends, my name is Alexia van Oranje and I am a princess in the Netherlands!",
            PhoneNumber = "0100-0200",
            Birthday = DateTime.ParseExact("2005-06-26 12:00", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var result = _profileService.UpdateProfile(profile);

        // Assert
        Assert.Null(result!);
    }

    [Fact]
    public void DeleteProfileTest()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile
        {
            ProfileId = 4,
            UserId = "google-oauth2|114384941823729227604",
            UserName = "borisje",
            DisplayName = "Boris",
            About = "Ik ga stoppen met Vybes, ontvriend iedereen!",
            PhoneNumber = "0100-0200",
            Birthday = DateTime.ParseExact("1996-04-13 00:30", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        // Act
        var result = _profileService.DeleteProfile(profile);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void DeleteProfileTest_FailByInvalidProfile()
    {
        // Arrange
        CreateDb();
        
        var profile = new Profile
        {
            ProfileId = 7, // This profile id does not exist, so the profile should not be deleted
            UserId = "google-oauth2|114384941823729227604",
            UserName = "borisje",
            DisplayName = "Boris",
            About = "Ik ga stoppen met Vybes, ontvriend iedereen!",
            PhoneNumber = "0100-0200",
            Birthday = DateTime.ParseExact("1996-04-13 00:30", "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        // Act
        var result = _profileService.DeleteProfile(profile);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void FindProfilesByDisplayNameTest()
    {
        // Arrange
        CreateDb();

        var displayName = "Alex";

        // Act
        var result = _profileService.FindProfilesByDisplayName(displayName);

        // Assert
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    public void FindProfilesByDisplayNameTest_OneResult()
    {
        // Arrange
        CreateDb();

        var displayName = "Pim";

        // Act
        var result = _profileService.FindProfilesByDisplayName(displayName);

        // Assert
        Assert.Single(result);
    }
    
    [Fact]
    public void FindProfilesByDisplayNameTest_NoResults()
    {
        // Arrange
        CreateDb();

        var displayName = "Erik";

        // Act
        var result = _profileService.FindProfilesByDisplayName(displayName);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void FindProfilesByUserNameTest()
    {
        // Arrange
        CreateDb();

        var userName = "Alex";

        // Act
        var result = _profileService.FindProfilesByUserName(userName);

        // Assert
        Assert.Equal(2, result.Count);
    }
    
    [Fact]
    public void FindProfilesByUserNameTest_OneResult()
    {
        // Arrange
        CreateDb();

        var userName = "pim";

        // Act
        var result = _profileService.FindProfilesByUserName(userName);

        // Assert
        Assert.Single(result);
    }
    
    [Fact]
    public void FindProfilesByUserNameTest_NoResults()
    {
        // Arrange
        CreateDb();

        var userName = "erik";

        // Act
        var result = _profileService.FindProfilesByUserName(userName);

        // Assert
        Assert.Empty(result);
    }
}