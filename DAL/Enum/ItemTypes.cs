﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enum
{
    /// <summary>
    /// Признаки предмета расчёта
    ///  ФФД 1.0.5
    /// </summary>
    [DataContract]
    public enum ItemTypes
    {
        [EnumMember]
        НеПрименяется = 0,

        /// <summary>
        /// Товар, за исключением подакцизного товара
        /// </summary>
        [EnumMember]
        Товар = 1,

        /// <summary>
        /// Подакцизный товар
        /// </summary>
        [EnumMember]
        ПодакцизныйТовар,

        /// <summary>
        /// Работа
        /// </summary>
        [EnumMember]
        Работа,

        /// <summary>
        /// Услуга
        /// </summary>
        [EnumMember]
        Услуга,

        /// <summary>
        /// Приём ставок при деятельность по организации и проведению азартных игр
        /// </summary>
        [EnumMember]
        ПриемСтавок,

        /// <summary>
        /// Выплата выигрышей в азартных играх
        /// </summary>
        [EnumMember]
        ВыплатаВыигрышейВАзартныхИграх,

        /// <summary>
        /// Реализация лотерейных билетов или ставок при деятельность по организации и проведению лотерей
        /// </summary>
        [EnumMember]
        РеализацияЛотерейныхБилетов,

        /// <summary>
        /// Выплата выигрышей в лотереях
        /// </summary>
        [EnumMember]
        ВыплатаВыигрышейВЛотереях,

        /// <summary>
        /// Прав на использование результатов интеллектуальной деятельности или средств индивидуализации
        /// </summary>
        [EnumMember]
        ПравНаИспользованиеИнтелектуальнойДеятельности,

        /// <summary>
        /// Аванс, задаток, предоплата, кредит, взносе в счет оплаты, пени, штраф, вознаграждение, бонус и иной аналогичный предмет расчета
        /// </summary>
        [EnumMember]
        АвансЗадатокПредоплатаКредит,

        /// <summary>
        /// Предмет расчета, состоящий из предметов, каждому из которых может быть присвоено значение от 0 до 10 (набор)
        /// </summary>
        [EnumMember]
        ПредметРасчета,

        /// <summary>
        /// Предмет расчета, не относящийся к предметам расчета, которым может быть присвоено значение от 0 до 11
        /// </summary>
        [EnumMember]
        ПредметРасчетаНеОтносящийсяКПредметамРасчета,

        /// <summary>
        /// 1С Розница 2 впервые такое отправила.
        /// </summary>
        [EnumMember]
        НеПрименяется13 = 13,
        [EnumMember]
        ИмущественноеПраво,
        [EnumMember]
        ВнереализационныйДоход,
        [EnumMember]
        СтраховыеВзносы,
        [EnumMember]
        ТорговыйСбор,
        [EnumMember]
        КурортныйСбор,
        [EnumMember]
        Залог,
        [EnumMember]
        Расход,
        [EnumMember]
        ВзносыНаОбязательноеПенсионноеСтрахованиеИП,
        [EnumMember]
        ВзносыНаОбязательноеПенсионноеСтрахование,
        [EnumMember]
        ВзносыНаОбязательноеМедицинскоеСтрахованиеИП,
        [EnumMember]
        ВзносыНаОбязательноеМедицинскоеСтрахование,
        [EnumMember]
        ВзносыНаОбязательноеСоциальноеСтрахование,
        [EnumMember]
        ПлатежКазино,
        [EnumMember]
        Выдача_денежных_средств_банковским_платежным_агентом,
        [EnumMember]
        Подакцизный_товар_подлежащий_маркировке_средством_идентификации_не_имеющем_кода_маркировки = 30,
        [EnumMember]
        Подакцизный_товар_подлежащий_маркировке_средством_идентификации_имеющем_код_маркировки,
        [EnumMember]
        Товар_подлежащей_маркировке_средством_идентификации_не_имеющем_кода_маркировки_за_исключением_подакцизного_товара,
        [EnumMember]
        Товар_подлежащей_маркировке_средством_идентификации_имеющем_код_маркировки_за_исключением_подакцизного_товара,
    }
}