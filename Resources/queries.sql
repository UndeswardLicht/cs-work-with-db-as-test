with tbl as  
(select t.id, p.name as project, t.name as test, (end_time-start_time) as min_time_sec
from test t
join project p
on t.project_id = p.id
where end_time is not null)
select project, test, min(min_time_sec) as min_time
from tbl
group by project, test
order by project, test;

select p.name as project, count(distinct(t.name)) as unique_tests
from test t
join project p
on t.project_id = p.id
group by project;

select p.name as project, t.name as test, start_time
from test t
join project p
on t.project_id = p.id
where start_time > '2016-10-13'
order by project, test;

select browser, count(name) as tests from test
where browser = 'chrome'
group by browser
union
select browser, count(name) as tests from test
where browser = 'firefox'
group by browser;





