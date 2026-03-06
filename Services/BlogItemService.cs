using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Services.Context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace blogapi.Services
{
    public class BlogItemService
    {
        private readonly DataContext _context;

public BlogItemService(DataContext context)
{
    _context = context;
}

       public bool AddBlogItems(BlogItemModel newBlogItem)
        {
         bool result;
         _context.Add(newBlogItem);
         result = _context.SaveChanges()!=0;
         return result;
        }

        public bool DeleteBlogItem(BlogItemModel blogItemToDelete)
        {
            _context.Update(blogItemToDelete);
           return _context.SaveChanges ( )!=0;
        }

        public  IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

     public List<BlogItemModel> GetItemsByTag(string tag)
        {
            List<BlogItemModel>AllBlogsWithTag = new List<BlogItemModel>();
            var allItems = GetAllBlogItems().ToList();
            for(int i =0; i < allItems.Count; i++)
            {
                BlogItemModel Item = allItems[i];
                var itemArr = Item.Tags.Split(',');

                for(int j = 0; j< itemArr.Length; j++)
                {
                    
                    if(itemArr[j].Contains(tag))
                    {
                        
AllBlogsWithTag.Add(Item);
break;

                    }
                }


            }

            return AllBlogsWithTag;
        }

        public IEnumerable<BlogItemModel> GetBlogItemsByCategory(string category)
        {
           return _context.BlogInfo.Where(item=>item.Category == category);
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(object date)
        {
            return _context.BlogInfo.Where(item => item.Date == date);
        }

        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
           _context.Update(blogUpdate);
           return _context.SaveChanges() !=0;
        }

        public IEnumerable <BlogItemModel>GetPublishedItems()
        {
            return _context.BlogInfo.Where(ItemsFeature => ItemsFeature.IsPublished);
        }

        
    }
}