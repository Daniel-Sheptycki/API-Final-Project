using GroupProjectStart.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupProjectStart.Data
{
    public class AppDbContext : DbContext
    {

        private static int offerAmount = 0;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            SeedData();
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<SkillOffer> SkillOffers => Set<SkillOffer>();

        private void SeedData()
        {
            //15 Skills offered
            var skillOffers = new List<SkillOffer>
            {
                new SkillOffer
                {
                    Id = ++offerAmount,
                    Title = "Graphic Design",
                    Description = "I can design logos, posters, and branding materials.",
                    Category = "Design",
                    Location = "New York"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Plumbing Services",
                    Description = "Fix leaks, install pipes, and repair water heaters.",
                    Category = "Home Improvement",
                    Location = "Los Angeles"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Tutoring",
                    Description = "Math and science tutoring for high school students.",
                    Category = "Education",
                    Location = "Chicago"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Web Development",
                    Description = "Build responsive websites using HTML, CSS, JavaScript, and frameworks like React.",
                    Category = "IT & Software",
                    Location = "Remote"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Photography",
                    Description = "Capture stunning portraits, landscapes, and events with professional-grade equipment.",
                    Category = "Creative Arts",
                    Location = "San Francisco"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Personal Training",
                    Description = "Customized fitness plans and workout sessions for all fitness levels.",
                    Category = "Health & Wellness",
                    Location = "Miami"
                },
                new SkillOffer
                {
                    Id = ++offerAmount ,
                    Title = "Cooking Classes",
                    Description = "Learn how to cook delicious meals from around the world, including Italian, Indian, and Japanese cuisine.",
                    Category = "Food & Beverage",
                    Location = "Austin"
                },
                new SkillOffer
                {
                    Id = ++offerAmount  ,
                    Title = "Guitar Lessons",
                    Description = "Beginner to advanced guitar lessons focusing on techniques, theory, and performance.",
                    Category = "Music",
                    Location = "Nashville"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Dog Walking",
                    Description = "Reliable dog walking services for busy pet owners.",
                    Category = "Pets",
                    Location = "Seattle"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Data Analysis",
                    Description = "Analyze and visualize data using Python, Excel, and tools like Tableau or Power BI.",
                    Category = "Business & Consulting",
                    Location = "Chicago"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Yoga Instruction",
                    Description = "Private or group yoga sessions tailored to your needs, suitable for all levels.",
                    Category = "Health & Wellness",
                    Location = "Denver"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Home Cleaning",
                    Description = "Thorough cleaning services for homes, apartments, and offices.",
                    Category = "Home Improvement",
                    Location = "Boston"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Mobile App Development",
                    Description = "Design and develop mobile apps for iOS and Android platforms.",
                    Category = "IT & Software",
                    Location = "Remote"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Public Speaking Coaching",
                    Description = "Improve your public speaking skills with personalized coaching and practice sessions.",
                    Category = "Education",
                    Location = "Washington D.C."
                },
                new SkillOffer
                {   
                    Id = ++offerAmount  ,
                    Title = "Car Repair",
                    Description = "Diagnose and fix car issues, including engine repairs, oil changes, and tire replacements.",
                    Category = "Automotive",
                    Location = "Houston"
                },
                new SkillOffer
                {   
                    Id = ++offerAmount ,  
                    Title = "Interior Design",
                    Description = "Transform your living spaces with creative interior design solutions.",
                    Category = "Design",
                    Location = "Los Angeles"
                }
            };

            SkillOffers.AddRange(skillOffers);
            SaveChanges();
        }
    }
}
