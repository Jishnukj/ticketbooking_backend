using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Repo
{
	public interface IBookingRepo
	{
		Booking getBookingbyId(int id);
		bool addBooking(Booking booking);
		List<Booking> getAllbookings();
	}

}

