create database poscomp;
use poscomp; 

create table user(
    id integer auto_increment not null,
    member_since varchar(256) not null,
    username varchar(20) not null,
    email varchar(40) not null,
    password varchar(40) not null,
    real_name varchar(128),
    institution varchar(128),
    primary key(id)
);

 create table question(
    id integer auto_increment not null,
    statement varchar(512) not null,
    alt_a varchar(256) not null,
    alt_b varchar(256) not null,
    alt_c varchar(256) not null,
    alt_d varchar(256) not null,
    alt_e varchar(256) not null,
    answer varchar(256) not null,
    img_link varchar(256),
    primary key(id)
);

create table test(
    user_id integer not null,
    id integer not null auto_increment,
    timestart varchar(256) not null,
    timeend varchar(256) not null,
    math_number_questions integer not null,
    fund_number_questions integer not null,
    tech_number_questions integer not null,
    math_correct_answers integer not null,
    fund_correct_answers integer not null,
    tech_correct_answers integer not null,
    accuracy float not null,
    primary key(id),
    foreign key(user_id) references user(id)
); 

create table question_on_test(
    test_id integer not null,
    question_id integer not null,
    foreign key(test_id) references test(id),
    foreign key(question_id) references question(id)
);     
    