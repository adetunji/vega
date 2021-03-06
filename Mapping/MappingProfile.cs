using System.Linq;
using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();

            // API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
							.ForMember(v => v.ContactName, opt => opt.MapFrom( vr => vr.Contact.name))
							.ForMember(v => v.ContactEmail, opt => opt.MapFrom( vr => vr.Contact.email))
							.ForMember(v => v.Features, opt => opt.
								MapFrom( vr => vr.Features.Select(id => new VehicleFeature {FeatureId = id})));
        }
    }
}