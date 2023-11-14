using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Models
{
    public class TeanToTeamMemberListConverter :
              ITypeConverter<ClassRoutineListDto, IEnumerable<ClassRoutine>>
    {
        public IEnumerable<ClassRoutine> Convert
        (ClassRoutineListDto source, IEnumerable<ClassRoutine> destination, ResolutionContext context)
        {
            /*first mapp from People, then from Team*/
            foreach (var model in source.perodListForm.Select
                    (e => context.Mapper.Map<ClassRoutine>(e)))
            {
                context.Mapper.Map(source, model);
                yield return model;
            }

            /*first mapp from Team, then from People*/
            //foreach (var member in source.Members)
            //{
            //    var model = context.Mapper.Map<TeamMember>(source);
            //    context.Mapper.Map(member, model);
            //    yield return model;
            //}
        }
    }
}
