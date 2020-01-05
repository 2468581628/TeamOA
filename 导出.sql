--------------------------------------------------------
--  文件已创建 - 星期日-一月-05-2020   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence COST_SEQUENCE
--------------------------------------------------------

   CREATE SEQUENCE  "OA"."COST_SEQUENCE"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 ORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence LEAVE_SEQUENCE
--------------------------------------------------------

   CREATE SEQUENCE  "OA"."LEAVE_SEQUENCE"  MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence USER_TABLE_ID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "OA"."USER_TABLE_ID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 61 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table COST
--------------------------------------------------------

  CREATE TABLE "OA"."COST" 
   (	"USER_ID" NUMBER, 
	"COSTTYPE" VARCHAR2(20 BYTE), 
	"COSTCOUNT" NUMBER, 
	"FILENAME" VARCHAR2(20 BYTE), 
	"NEWFILENAME" VARCHAR2(50 BYTE), 
	"DATETIME" DATE, 
	"STATUS" VARCHAR2(20 BYTE), 
	"ID" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table DEPARTMENT
--------------------------------------------------------

  CREATE TABLE "OA"."DEPARTMENT" 
   (	"ID" NUMBER, 
	"NAME" VARCHAR2(20 BYTE), 
	"STATUS" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table LEAVE
--------------------------------------------------------

  CREATE TABLE "OA"."LEAVE" 
   (	"L_ID" NUMBER, 
	"S_DATE" DATE, 
	"E_DATE" DATE, 
	"USER_ID" NUMBER, 
	"TYPE" VARCHAR2(20 BYTE), 
	"REMARK" VARCHAR2(200 BYTE), 
	"STATUS" NVARCHAR2(20)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table USER_TABLE
--------------------------------------------------------

  CREATE TABLE "OA"."USER_TABLE" 
   (	"ID" NUMBER, 
	"USERNAME" VARCHAR2(20 BYTE), 
	"PASSWORD" VARCHAR2(20 BYTE), 
	"ACCOUNT" VARCHAR2(20 BYTE), 
	"TEL" VARCHAR2(20 BYTE), 
	"STATUS" NUMBER(2,0), 
	"DWPARTMENT_ID" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into OA.COST
SET DEFINE OFF;
Insert into OA.COST (USER_ID,COSTTYPE,COSTCOUNT,FILENAME,NEWFILENAME,DATETIME,STATUS,ID) values (1,'前期',12121,'sql schema.txt','ef3363d7-5927-48d9-bc2e-b0b5834b91f6',to_date('2020-01-05 01:00:58','YYYY-MM-DD HH24:MI:SS'),'未审核',1);
REM INSERTING into OA.DEPARTMENT
SET DEFINE OFF;
Insert into OA.DEPARTMENT (ID,NAME,STATUS) values (1,null,1);
Insert into OA.DEPARTMENT (ID,NAME,STATUS) values (2,null,1);
Insert into OA.DEPARTMENT (ID,NAME,STATUS) values (3,null,1);
REM INSERTING into OA.LEAVE
SET DEFINE OFF;
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (5,to_date('2020-01-01 11:38:30','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-22 20:04:04','YYYY-MM-DD HH24:MI:SS'),1,'病假','啊大苏打撒擦','δ???');
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (6,to_date('2020-01-01 11:41:46','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-01 11:41:47','YYYY-MM-DD HH24:MI:SS'),1,'调休','但是','δ???');
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (7,to_date('2020-01-01 11:41:46','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-01 11:41:47','YYYY-MM-DD HH24:MI:SS'),1,'调休','但是','未审核');
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (8,to_date('2020-01-01 12:38:17','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-01 12:38:19','YYYY-MM-DD HH24:MI:SS'),1,'调休','看看看看','未审核');
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (4,to_date('2020-01-01 08:41:36','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-01 08:41:37','YYYY-MM-DD HH24:MI:SS'),1,'调休',null,'未审核');
Insert into OA.LEAVE (L_ID,S_DATE,E_DATE,USER_ID,TYPE,REMARK,STATUS) values (9,to_date('2020-01-01 12:38:17','YYYY-MM-DD HH24:MI:SS'),to_date('2020-01-01 12:38:19','YYYY-MM-DD HH24:MI:SS'),1,'调休','看看看看','未审核');
REM INSERTING into OA.USER_TABLE
SET DEFINE OFF;
Insert into OA.USER_TABLE (ID,USERNAME,PASSWORD,ACCOUNT,TEL,STATUS,DWPARTMENT_ID) values (1,'admin','admin','admin','18551572521',1,null);
--------------------------------------------------------
--  DDL for Index USER_TABLE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "OA"."USER_TABLE_PK" ON "OA"."USER_TABLE" ("ACCOUNT") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Trigger ACCOUNT_TRIGGER
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "OA"."ACCOUNT_TRIGGER" 
before insert
on USER_TABLE
for each row
begin
    select USER_TABLE_ID_SEQ.nextval into :new.id from dual; 
end;
/
ALTER TRIGGER "OA"."ACCOUNT_TRIGGER" ENABLE;
--------------------------------------------------------
--  DDL for Trigger COST_TRIGGER
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "OA"."COST_TRIGGER" 
before insert
on COST
for each row
begin
    select COST_SEQUENCE.nextval into :new.ID from dual; 
end;
/
ALTER TRIGGER "OA"."COST_TRIGGER" ENABLE;
--------------------------------------------------------
--  DDL for Trigger LEAVE_TRIGGER
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "OA"."LEAVE_TRIGGER" 
before insert
on LEAVE
for each row
begin
    select LEAVE_SEQUENCE.nextval into :new.L_ID from dual; 
end;
/
ALTER TRIGGER "OA"."LEAVE_TRIGGER" ENABLE;
--------------------------------------------------------
--  Constraints for Table USER_TABLE
--------------------------------------------------------

  ALTER TABLE "OA"."USER_TABLE" ADD CONSTRAINT "USER_TABLE_PK" PRIMARY KEY ("ACCOUNT")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("STATUS" NOT NULL ENABLE);
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("TEL" NOT NULL ENABLE);
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("ACCOUNT" NOT NULL ENABLE);
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("USERNAME" NOT NULL ENABLE);
  ALTER TABLE "OA"."USER_TABLE" MODIFY ("ID" NOT NULL ENABLE);
