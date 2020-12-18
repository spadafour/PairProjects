-- select the park name, campground name, open_from_mm, open_to_mm & daily_fee ordered by park name and then campground name
select (select name from park where campground.park_id=park.park_id) as 'Park_Name', campground.name, open_from_mm, open_to_mm, daily_fee from campground
order by 'Park_Name', campground.name

-- select the park name and the total number of campgrounds for each park ordered by park name
select park.name, count(campground.campground_id) as 'Total Number of Campgrounds' from campground
join park on park.park_id = campground.park_id
group by park.name

-- select the park name, campground name, site number, max occupancy, accessible, max rv length, utilities where the campground name is 'Blackwoods'
select (select park.name where park.park_id=(select campground.park_id where campground.campground_id=site.campground_id)) as 'Park_Name',
(select campground.name where site.campground_id=campground.campground_id) as 'Campground_Name',
site_number, max_occupancy, accessible, max_rv_length, utilities from site
join campground on site.campground_id=campground.campground_id
join park on campground.park_id=park.park_id
where site.campground_id=(select campground.campground_id where campground.name='Blackwoods')

/*
  select park name, campground, total number of sites (column alias 'number_of_sites') ordered by park
  data should look like below:
  -------------------------------------------------
    park				campground							number_of_sites
	Acadia				Blackwoods							12
    Acadia				Seawall								12
    Acadia				Schoodic Woods						12
    Arches				"Devil's Garden"					8
    Arches				Canyon Wren Group Site				1
    Arches				Juniper Group Site					1
    Cuyahoga Valley		The Unnamed Primitive Campsites		5
  -------------------------------------------------
*/
select
(select park.name where campground.park_id=park.park_id) as 'park',
campground.name,
count(site_number) as 'number_of_sites'
from campground
join park on campground.park_id=park.park_id
join site on campground.campground_id=site.campground_id
group by park.name, campground.park_id, park.park_id, campground.name
order by park.name, number_of_sites desc

-- select site number, reservation name, reservation from and to date ordered by reservation from date
select site_id, name, from_date, to_date from reservation
group by site_id, name, from_date, to_date
order by from_date

/*
  select campground name, total number of reservations for each campground ordered by total reservations desc
  data should look like below:
  -------------------------------------------------
    name								total_reservations
	Seawall								13
    Blackwoods							9
    "Devil's Garden"					7
    Schoodic Woods						7
    Canyon Wren Group Site				4
    Juniper Group Site					4
  -------------------------------------------------
*/
select campground.name, count(reservation.reservation_id) as 'Total Reservations' from campground
join site on campground.campground_id = site.campground_id
join reservation on site.site_id = reservation.site_id
group by campground.name
order by 'Total Reservations' desc