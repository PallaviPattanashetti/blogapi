using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogItemService _data;
        public BlogController(BlogItemService dataFromService)
        {
            _data = dataFromService;
        }

        //AddBlogItems
        [HttpPost("AddBlogItems")]
        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            return _data.AddBlogItems(newBlogItem);
        }

//GetBlogItems
[HttpGet("GetBlogItems")]
public IEnumerable<BlogItemModel>GetAllBlogItems()
        {
            
            return _data.GetAllBlogItems();
        }

//GetBlogItemsByCategory

[HttpGet("GetBlogItemsByCategory/{category}")]
public IEnumerable<BlogItemModel>GetItemsByCategory( string category)
        {
            return _data.GetBlogItemsByCategory(category);
        }

//GetItemstag
[HttpGet("GetItemsByTag/{tag}")]
public List<BlogItemModel>GetItemsByTag(string tag)
        {
            return _data.GetItemsByTag(tag);
        }

//GetItemByDate
[HttpGet("GetItemByDate/{Date}")]
public IEnumerable<BlogItemModel>GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

//UpdateBlogItems
[HttpPut("blogUpdate")]
public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
            
            return _data.UpdateBlogItems(blogUpdate);
        }


//DeleteBlogItems
[HttpPut("DeleteBlogItems/{BlogToDelete}")]
public bool DeleteBlogItem(BlogItemModel BlogItemToDelete)
        {
            return _data.DeleteBlogItem(BlogItemToDelete);
        }

//GetPublishedBlogItems
[HttpGet("GetPublishedBlogItems")]
public IEnumerable<BlogItemModel>GetPublishedBlogItems()
        {
            return _data.GetPublishedItems();
        
    }
}
}