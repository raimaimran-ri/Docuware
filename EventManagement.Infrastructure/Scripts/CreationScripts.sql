CREATE SEQUENCE user_role_id_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE user_role (
    id INT PRIMARY KEY DEFAULT nextval('user_role_id_seq'),
    name TEXT NOT NULL
);

CREATE SEQUENCE user_id_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE "user" (
    id INT PRIMARY KEY DEFAULT nextval('user_id_seq'),
    name TEXT NOT NULL,
    email TEXT NOT NULL,
    password_hash TEXT NOT NULL,
    phone_number TEXT NOT NULL,
    user_role_id INT NOT NULL,
    CONSTRAINT fk_user_role FOREIGN KEY (user_role_id) REFERENCES user_role(id)
);

CREATE SEQUENCE event_id_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE event (
    id INT PRIMARY KEY DEFAULT nextval('event_id_seq'),
    name TEXT NOT NULL,
    description TEXT NOT NULL,
    location TEXT NOT NULL,
    start_time TIMESTAMP NOT NULL,
    end_time TIMESTAMP NOT NULL,
    created_on TIMESTAMP NOT NULL,
    created_by INT NOT NULL,
    CONSTRAINT fk_event_user FOREIGN KEY (created_by) REFERENCES "user"(id)
);

CREATE SEQUENCE event_registration_id_seq START WITH 1 INCREMENT BY 1;

CREATE TABLE event_registration (
    id INT PRIMARY KEY DEFAULT nextval('event_registration_id_seq'),
    eventid INT NOT NULL,
    name TEXT,
    phone_number TEXT,
    email_address TEXT,
    user_id INT,
    CONSTRAINT fk_eventregistration_event FOREIGN KEY (eventid) REFERENCES event(id),
    CONSTRAINT fk_eventregistration_user FOREIGN KEY (user_id) REFERENCES "user"(id)
);