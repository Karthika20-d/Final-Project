using OnlineRealEstate.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineRealEstate.DAL
{
    public class PropertyRepositary
    {
        List<Property> propertyList = new List<Property>();
        public int Create(Property property)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                propertyContext.Property.Add(property);
                return propertyContext.SaveChanges();
                //SqlParameter propertyType = new SqlParameter("@PropertyType", property.PropertyType);
                //SqlParameter location = new SqlParameter("@Location", property.Location);
                //return propertyContext.Database.ExecuteSqlCommand("Property_Insert @PropertyType,@Area,@Location", propertyType, location);

            }
             
        }
        public IEnumerable<Property> DisplayPropertyDetails()
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                return propertyContext.Property.Include("PropertyType").ToList();
            }
        }
        public Property Update(int landId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                Property property = new Property();
                property = propertyContext.Property.Find(landId);
                return property;
            }
        }
        public void UpdatePropertyDetails(Property property)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                propertyContext.Entry(property).State = EntityState.Modified;
                propertyContext.SaveChanges();
                //SqlParameter propertyType = new SqlParameter("@PropertyType", property.PropertyType);
                //SqlParameter location = new SqlParameter("@Location", property.Location);
                //SqlParameter landId = new SqlParameter("@landId", property.PropertyId);
                //propertyContext.Database.ExecuteSqlCommand("Property_Update @landId,@PropertyType,@Area,@Location", landId, propertyType, location);

            }
        }
        public void Delete(int landId)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {

                Property propertyvalue = propertyContext.Property.Find(landId);
                propertyContext.Property.Remove(propertyvalue);
                propertyContext.SaveChanges();
                //SqlParameter landID = new SqlParameter("@landId", landId);
                //propertyContext.Database.ExecuteSqlCommand("Property_Delete @landId",landID);
            }

        }
        public IEnumerable<PropertyType> GetPropertyType()
        {
            using(PropertyContext propertyContext =new PropertyContext())
            {
                return propertyContext.PropertyType.ToList();
            }
        }
        public ICollection<PropertyFeature> GetFeature(int typeId)
        {
            using(PropertyContext propertyContext=new PropertyContext())
            {

                PropertyFeature propertyFeatures = new PropertyFeature();
                //propertyFeatures = IQueryable<PropertyFeature>(from property in propertyContext.PropertyFeatures
                //                                               where property.PropertyTypeID == typeId
                //                                               select new PropertyFeature
                //                                               {
                //                                                   PropertyFeatureId = property.PropertyFeatureId,
                //                                                   PropertyTypeID = property.PropertyTypeID,
                //                                                   PropertyFeatureName = property.PropertyFeatureName,
                //                                                   PropertyType = property.PropertyType
                //                                               }).FirstOrDefault();
                return propertyContext.PropertyFeatures.Where(id=>id.PropertyTypeID==typeId).ToList();
                
               // propertyFeatures = propertyFeatures1;
               // return propertyFeatures1;
            }
        }
        public void AddPropertyValue(PropertyValues propertyValues,int []Value,int[] PropertyFeature)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                int index = 0;
                foreach(int value in Value)
                {
                    propertyValues.Value = value;
                    propertyValues.PropertyFeatureId = PropertyFeature[index];
                    propertyContext.PropertyValues.Add(propertyValues);
                    propertyContext.SaveChanges();
                }
                
            }
        }
    }
}
