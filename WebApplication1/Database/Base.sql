--CREATE table students(id serial primary key,
--            full_name varchar,phone varchar,
--           student_group varchar);
           
--CREATE table teacher(id serial primary key,
--            full_name varchar,salary decimal,
--           phone varchar,age INT);
           
--CREATE table Course(id serial primary key,
--            name varchar,duration varchar,
--           student_amount varchar,
--          teacher_id serial unique 
--          references teacher(id));
          
--CREATE table connection(student_id serial REFERENCES
--             students(id),
--             course_id serial REFERENCES
--             course(id));
