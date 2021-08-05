using Application.DTOs;
using Application.Models;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Event, EventDTO>();

            CreateMap<EventCreateModel, Event>();

            CreateMap<EventEditModel, Event>();

            CreateMap<Notification, NotificationDTO>();

            CreateMap<NotificationCreateModel, Notification>();

            CreateMap<NotificationEditModel, Notification>();

            CreateMap<User, UserDTO>();

            CreateMap<UserCreateModel, User>();

            CreateMap<UserEditModel, User>();

            


            //CreateMap<Order, OrderWithOrderRoomsDTO>()
            //    .ForMember(dto => dto.OrderWithCustomerPersonFullNameDTO,
            //               options => options.MapFrom(o => o))
            //    .ForMember(dto => dto.OrderRoomWithoutOrderIdWithRoomInfoDTOs,
            //               options => options.MapFrom(o => o.OrderRooms));

            //CreateMap<OrderEditModel, Order>();

            //CreateMap<OrderRoom, OrderRoomDetailsDTO>()
            //    .ForMember(dto => dto.OrderRoomWithoutOrderIdDTO,
            //               options => options.MapFrom(or => or))
            //    .ForMember(dto => dto.OrderWithCustomerPersonFullNameDTO,
            //               options => options.MapFrom(or => or.Order))
            //    .ForMember(dto => dto.RoomCategoryDTO,
            //               options => options.MapFrom(or => or.Room.RoomCategory))
            //    .ForMember(dto => dto.RoomRankDTO,
            //               options => options.MapFrom(or => or.Room.RoomCategory.RoomRank));

            //CreateMap<OrderRoom, OrderRoomDTO>();

            //CreateMap<OrderRoom, OrderRoomListItemDTO>()
            //    .ForMember(dto => dto.OrderRoomWithoutOrderIdWithRoomInfoDTO,
            //               options => options.MapFrom(o => o))
            //    .ForMember(dto => dto.OrderWithCustomerPersonFullNameDTO,
            //               options => options.MapFrom(or => or.Order));

            //CreateMap<OrderRoom, OrderRoomWithoutOrderIdWithRoomInfoDTO>()
            //    .ForMember(dto => dto.RoomNumber,
            //               options => options.MapFrom(or => or.Room.RoomNumber))
            //    .ForMember(dto => dto.RoomCategoryId,
            //               options => options.MapFrom(or => or.Room.RoomCategoryId));

            //CreateMap<OrderRoomCreateModel, OrderRoom>();

            //CreateMap<Person, PersonDTO>();

            //CreateMap<Person, PersonWithCustomerIdAndGuestIdDTO>();

            //CreateMap<PersonCreateModel, Person>();

            //CreateMap<PersonEditModel, Person>();

            //CreateMap<Room, RoomDTO>();

            //CreateMap<RoomCategory, RoomCategoryDTO>();

            //CreateMap<RoomRank, RoomRankDTO>();


        }
    }
}
