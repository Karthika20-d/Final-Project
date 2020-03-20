using OnlineRealEstate.BL;
using OnlineRealEstate.Entity;
using OnlineRealEstate.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
namespace OnlineRealEstate.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PropertyController : Controller
    {
        PropertyBL propertyBL = new PropertyBL();
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PropertyModel propertyModel)
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            Property property = new Property();
            if (ModelState.IsValid)
            {
                property=AutoMapper.Mapper.Map<PropertyModel, Property>(propertyModel);
                if (propertyBL.Create(property) > 0)
                {
                    TempData["TypeId"] = property;
                    return RedirectToAction("AddFeature", "PropertyFeature");
                }
                else
                {
                    ViewBag.Message = "failed";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Property property=propertyBL.Update(id);
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            PropertyModel propertyModel = AutoMapper.Mapper.Map<Property, PropertyModel>(property);
            return View(propertyModel);
        }
        [HttpPost]
        public ActionResult Edit(PropertyModel propertyModel)
        {
            IEnumerable<PropertyType> propertyTypes = propertyBL.GetPropertyType();
            ViewBag.propertyId = new SelectList(propertyTypes, "PropertyTypeID", "Type");
            Property property = new Property();
            if (ModelState.IsValid)
            {
                property = AutoMapper.Mapper.Map<PropertyModel, Property>(propertyModel);
                propertyBL.UpdatePropertyDetails(property);
                return RedirectToAction("DisplayPropertyDetails");
            }
            return View();

        }
        [HttpGet]
       // [OutputCache(Duration =10)]
        public ActionResult DisplayPropertyDetails()
        {
            IEnumerable<Property> property = propertyBL.DisplayPropertyDetails();
            TempData["Property"] = property;
            ViewBag.Message = DateTime.Now.ToString();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Property property = propertyBL.Update(id);
            PropertyModel propertyModel = AutoMapper.Mapper.Map<Property, PropertyModel>(property);
            return View(propertyModel);
        }
        [HttpPost]
        public ActionResult Delete(PropertyModel propertyModel)
        {
            propertyBL.Delete(propertyModel.PropertyId);
            return RedirectToAction("DisplayPropertyDetails");
        }

    }
}