using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InspectMasterCategory
{
    public class InspectMstCategoryBll :DemoAppService, IInspectMstCategoryAfl
    {
        private readonly IInspectMstCategoryRepo _inspectMstCategories;
        public InspectMstCategoryBll(IInspectMstCategoryRepo inspectMstCategories)
        {
            _inspectMstCategories = inspectMstCategories;
        }

        public async Task<InspectMstCategoryDto> CreateAsync(CreateUpdateInspectMstCategoryDto input)
        {
            InspectMstCategory inspectMstCategory;
            
            if (input.Id > 0) {
                var insMstCategory = await _inspectMstCategories.GetAsync(input.Id);
                inspectMstCategory = ObjectMapper.Map(input, insMstCategory);               
                await _inspectMstCategories.UpdateAsync(inspectMstCategory);
            }
            else
            {     
                inspectMstCategory = ObjectMapper.Map<CreateUpdateInspectMstCategoryDto, InspectMstCategory>(input);
                await _inspectMstCategories.InsertAsync(inspectMstCategory);
            }                        
            return ObjectMapper.Map<InspectMstCategory, InspectMstCategoryDto>(inspectMstCategory);
        }

        public async Task UpdateAsync(int id, CreateUpdateInspectMstCategoryDto input)
        {
            var insMstCategory = await _inspectMstCategories.GetAsync(id);

            insMstCategory.OrgID = input.OrgID;
            insMstCategory.InspectCatIdnCode = input.InspectCatIdnCode;
            insMstCategory.PermitIdnCode = input.PermitIdnCode;
            insMstCategory.AppTypeIdnCode = input.AppTypeIdnCode;
            insMstCategory.ChkFormID = input.ChkFormID;
            await _inspectMstCategories.UpdateAsync(insMstCategory);       
        }
    }
}
