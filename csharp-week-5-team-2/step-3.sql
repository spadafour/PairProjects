-- CAMPGROUND TABLE
-----------------------------------------------

-- select name and daily fee of all campgrounds
select campground.name, daily_fee from campground

-- select name and daily fee of all campgrounds ordered by campground name
select campground.name, daily_fee from campground
order by name

-- select name, open from month, open to month, and daily fee of the campgrounds where daily fee is less than $100
select name, open_from_mm, open_to_mm, daily_fee from campground
where daily_fee<100

-- select name and daily fee of the campgrounds where the campground is open all year long
select name, daily_fee from campground
where open_from_mm=1 and open_to_mm=12


-- PARK TABLE
-----------------------------------------------

-- select name and description of all parks order by established date in descending order
select name, description, establish_date from park
group by name, description, establish_date
order by establish_date desc

-- select name and description of all parks in Ohio
select name, description from park
where park.location = 'OHIO'

-- select name and description of all parks NOT in Ohio
select name, description from park
where location not like 'ohio'

-- select the total number of visitors for all parks
select sum(visitors) as 'Total Number of Visitors' from park

-- select the average number of visitors for all parks
select AVG(visitors) as 'Average Number of Visitors' from park

-- SITE TABLE
-----------------------------------------------

-- select all columns from site that have utilities hook up and order by max RV length with the largest coming first
select * from site
where utilities=1
order by max_rv_length desc

-- select total number of sites that have utilities hook up
select count(*) from site
where utilities=1


-- RESERVATION TABLE
-----------------------------------------------

-- select reservation id, site id, name, from date, to date of the reservations where the checkin date is between the first and last day of the current month (hard coded month is ok)
select reservation_id, site_id, name, from_date, to_date from reservation
where from_date between '2020-10-01' and '2020-10-31'

-- select all columns from reservation where name includes 'Reservation'
select * from reservation
where name like '%reservation%'

-- select the total number of reservations in the reservation table
select count(reservation_id) as total_reservations from reservation

-- select reservation id, site id, name of the reservations where site id is in the list 9, 20, 24, 45, 46
select reservation_id, site_id, name from reservation
where site_id in ('9', '20', '24', '25', '45', '46')

-- select the date and number of reservations for each date orderd by from_date in ascending order
select from_date, to_date, sum(reservation_id) as 'Total Reservations'  from reservation
group by from_date, to_date
order by from_date
