using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class RewardRepository
    {
        private static Dictionary<string, Reward> responses;
        static RewardRepository()
        {
            responses = new Dictionary<string, Reward>();
            responses.Add("Sashimi Salad 1", new Reward
            {
                Name = "Sashimi Salad 1",
                Description = "Organic greens topped with market fresh sashimi, wasabi soy vinaigrette.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/f8d3hipp7/sashimi_salad.jpg"
            });
            responses.Add("Seaweed Salad 1", new Reward 
            {
                Name = "Seaweed Salad 1",
                Description = "A nice seaweed salad.",
                Rewards = "Earn 10 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s30.postimg.org/vcsffv12l/seaweed_salad.jpg" 
            });
            responses.Add("Edamame 1", new Reward
            {
                Name = "Edamame 1",
                Description = "Boiled soy beans with salt.",
                Rewards = "Earn 50 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/3ykdmkknv/edamame.jpg"
            });
            responses.Add("Maguro 1", new Reward
            {
                Name = "Maguro 1",
                Description = "Tuna pieces.",
                Rewards = "Earn 20 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s2.postimg.org/j1n9awc6t/maguro.jpg"
            });
            responses.Add("Tekka Maki 1", new Reward
            {
                Name = "Tekka Maki 1",
                Description = "Tuna roll with wasabi.",
                Rewards = "Earn 30 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s14.postimg.org/hsd044hxp/tekka_maki.jpg"
            });
            responses.Add("California Rolls 1", new Reward
            {
                Name = "California Rolls 1",
                Description = "Crab sticks, avocado and cucumber.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s10.postimg.org/q5onsvwgl/california_rolls.jpg"
            });
            responses.Add("Sashimi Salad 2", new Reward
            {
                Name = "Sashimi Salad 2",
                Description = "Organic greens topped with market fresh sashimi, wasabi soy vinaigrette.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/f8d3hipp7/sashimi_salad.jpg"
            });
            responses.Add("Seaweed Salad 2", new Reward
            {
                Name = "Seaweed Salad 2",
                Description = "A nice seaweed salad.",
                Rewards = "Earn 10 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s30.postimg.org/vcsffv12l/seaweed_salad.jpg"
            });
            responses.Add("Edamame 2", new Reward
            {
                Name = "Edamame 2",
                Description = "Boiled soy beans with salt.",
                Rewards = "Earn 50 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/3ykdmkknv/edamame.jpg"
            });
            responses.Add("Maguro 2", new Reward
            {
                Name = "Maguro 2",
                Description = "Tuna pieces.",
                Rewards = "Earn 20 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s2.postimg.org/j1n9awc6t/maguro.jpg"
            });
            responses.Add("Tekka Maki 2", new Reward
            {
                Name = "Tekka Maki 2",
                Description = "Tuna roll with wasabi.",
                Rewards = "Earn 30 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s14.postimg.org/hsd044hxp/tekka_maki.jpg"
            });
            responses.Add("California Rolls 2", new Reward
            {
                Name = "California Rolls 2",
                Description = "Crab sticks, avocado and cucumber.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s10.postimg.org/q5onsvwgl/california_rolls.jpg"
            });
            responses.Add("Sashimi Salad 3", new Reward
            {
                Name = "Sashimi Salad 3",
                Description = "Organic greens topped with market fresh sashimi, wasabi soy vinaigrette.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/f8d3hipp7/sashimi_salad.jpg"
            });
            responses.Add("Seaweed Salad 3", new Reward
            {
                Name = "Seaweed Salad 3",
                Description = "A nice seaweed salad.",
                Rewards = "Earn 10 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s30.postimg.org/vcsffv12l/seaweed_salad.jpg" 
            });
            responses.Add("Edamame 3", new Reward
            {
                Name = "Edamame 3",
                Description = "Boiled soy beans with salt.",
                Rewards = "Earn 50 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/3ykdmkknv/edamame.jpg"
            });
            responses.Add("Maguro 3", new Reward
            {
                Name = "Maguro 3",
                Description = "Tuna pieces.",
                Rewards = "Earn 20 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s2.postimg.org/j1n9awc6t/maguro.jpg"
            });
            responses.Add("Tekka Maki 3", new Reward
            {
                Name = "Tekka Maki 3",
                Description = "Tuna roll with wasabi.",
                Rewards = "Earn 30 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s14.postimg.org/hsd044hxp/tekka_maki.jpg"
            });
            responses.Add("California Rolls 3", new Reward
            {
                Name = "California Rolls 3",
                Description = "Crab sticks, avocado and cucumber.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s10.postimg.org/q5onsvwgl/california_rolls.jpg"
            });
            responses.Add("Sashimi Salad 4", new Reward
            {
                Name = "Sashimi Salad 4",
                Description = "Organic greens topped with market fresh sashimi, wasabi soy vinaigrette.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/f8d3hipp7/sashimi_salad.jpg"
            });
            responses.Add("Seaweed Salad 4", new Reward
            {
                Name = "Seaweed Salad 4",
                Description = "A nice seaweed salad.",
                Rewards = "Earn 10 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s30.postimg.org/vcsffv12l/seaweed_salad.jpg" 
            });
            responses.Add("Edamame 4", new Reward
            {
                Name = "Edamame 4",
                Description = "Boiled soy beans with salt.",
                Rewards = "Earn 50 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/3ykdmkknv/edamame.jpg"
            });
            responses.Add("Maguro 4", new Reward
            {
                Name = "Maguro 4",
                Description = "Tuna pieces.",
                Rewards = "Earn 20 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s2.postimg.org/j1n9awc6t/maguro.jpg"
            });
            responses.Add("Tekka Maki 4", new Reward
            {
                Name = "Tekka Maki 4",
                Description = "Tuna roll with wasabi.",
                Rewards = "Earn 30 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s14.postimg.org/hsd044hxp/tekka_maki.jpg"
            });
            responses.Add("California Rolls 4", new Reward
            {
                Name = "California Rolls 4",
                Description = "Crab sticks, avocado and cucumber.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s10.postimg.org/q5onsvwgl/california_rolls.jpg"
            });
            responses.Add("Sashimi Salad 5", new Reward
            {
                Name = "Sashimi Salad 5",
                Description = "Organic greens topped with market fresh sashimi, wasabi soy vinaigrette.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/f8d3hipp7/sashimi_salad.jpg"
            });
            responses.Add("Seaweed Salad 5", new Reward
            {
                Name = "Seaweed Salad 5",
                Description = "A nice seaweed salad.",
                Rewards = "Earn 10 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s30.postimg.org/vcsffv12l/seaweed_salad.jpg" 
            });
            responses.Add("Edamame 5", new Reward
            {
                Name = "Edamame 5",
                Description = "Boiled soy beans with salt.",
                Rewards = "Earn 50 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s9.postimg.org/3ykdmkknv/edamame.jpg"
            });
            responses.Add("Maguro 5", new Reward
            {
                Name = "Maguro 5",
                Description = "Tuna pieces.",
                Rewards = "Earn 20 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s2.postimg.org/j1n9awc6t/maguro.jpg"
            });
            responses.Add("Tekka Maki 5", new Reward
            {
                Name = "Tekka Maki 5",
                Description = "Tuna roll with wasabi.",
                Rewards = "Earn 30 Partner's Pub Pounder points per dollar of eligible purchases.",
                ImageUrl = "http://s14.postimg.org/hsd044hxp/tekka_maki.jpg"
            });
            responses.Add("California Rolls 5", new Reward
            {
                Name = "California Rolls 5",
                Description = "Crab sticks, avocado and cucumber.",
                Rewards = "Earn 1 Partner's Pub Pounder point per dollar of eligible purchases.",
                ImageUrl = "http://s10.postimg.org/q5onsvwgl/california_rolls.jpg"
            });
        }
                
        public static IEnumerable<Reward> Responses
        {
            get { return responses.Values; }
        }
    }
}