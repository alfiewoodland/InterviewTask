using Fines.Core.Enums;
using Fines.Data.Models;

namespace Fines.Data.Seed;

public static class FinesSeedData
{
    public static List<FinesEntity> GetSeedData()
    {
        return new List<FinesEntity>
        {
            // Speeding Fines (F001-F005)
            new FinesEntity
            {
                Id = 1,
                FineNo = "F001",
                FineDate = new DateTime(2024, 3, 15),
                FineType = FineType.Speeding,
                CustomerName = "Michael Johnson",
                VehicleRegNo = "ABC123",
                VehicleDriverName = "Michael Johnson"
            },
            new FinesEntity
            {
                Id = 2,
                FineNo = "F002",
                FineDate = new DateTime(2024, 5, 22),
                FineType = FineType.Speeding,
                CustomerName = "Sarah Williams",
                VehicleRegNo = "XYZ789",
                VehicleDriverName = "Sarah Williams"
            },
            new FinesEntity
            {
                Id = 3,
                FineNo = "F003",
                FineDate = new DateTime(2024, 7, 8),
                FineType = FineType.Speeding,
                CustomerName = "David Brown",
                VehicleRegNo = "DEF456",
                VehicleDriverName = "Jennifer Brown"
            },
            new FinesEntity
            {
                Id = 4,
                FineNo = "F004",
                FineDate = new DateTime(2024, 9, 14),
                FineType = FineType.Speeding,
                CustomerName = "Emma Garcia",
                VehicleRegNo = "GHI321",
                VehicleDriverName = "Emma Garcia"
            },
            new FinesEntity
            {
                Id = 5,
                FineNo = "F005",
                FineDate = new DateTime(2024, 11, 29),
                FineType = FineType.Speeding,
                CustomerName = "Robert Martinez",
                VehicleRegNo = "JKL654",
                VehicleDriverName = "Robert Martinez"
            },

            // Parking Fines (F006-F010)
            new FinesEntity
            {
                Id = 6,
                FineNo = "F006",
                FineDate = new DateTime(2024, 2, 10),
                FineType = FineType.Parking,
                CustomerName = "Lisa Anderson",
                VehicleRegNo = "MNO987",
                VehicleDriverName = "Lisa Anderson"
            },
            new FinesEntity
            {
                Id = 7,
                FineNo = "F007",
                FineDate = new DateTime(2024, 4, 17),
                FineType = FineType.Parking,
                CustomerName = "James Wilson",
                VehicleRegNo = "PQR246",
                VehicleDriverName = "James Wilson"
            },
            new FinesEntity
            {
                Id = 8,
                FineNo = "F008",
                FineDate = new DateTime(2024, 6, 25),
                FineType = FineType.Parking,
                CustomerName = "Mary Thompson",
                VehicleRegNo = "STU135",
                VehicleDriverName = "Thomas Thompson"
            },
            new FinesEntity
            {
                Id = 9,
                FineNo = "F009",
                FineDate = new DateTime(2024, 8, 3),
                FineType = FineType.Parking,
                CustomerName = "William Davis",
                VehicleRegNo = "VWX802",
                VehicleDriverName = "William Davis"
            },
            new FinesEntity
            {
                Id = 10,
                FineNo = "F010",
                FineDate = new DateTime(2024, 10, 19),
                FineType = FineType.Parking,
                CustomerName = "Jennifer Rodriguez",
                VehicleRegNo = "YZA579",
                VehicleDriverName = "Jennifer Rodriguez"
            },

            // Red Light Violation Fines (F011-F015)
            new FinesEntity
            {
                Id = 11,
                FineNo = "F011",
                FineDate = new DateTime(2024, 1, 28),
                FineType = FineType.RedLightViolation,
                CustomerName = "Richard Lee",
                VehicleRegNo = "BCD147",
                VehicleDriverName = "Richard Lee"
            },
            new FinesEntity
            {
                Id = 12,
                FineNo = "F012",
                FineDate = new DateTime(2024, 3, 30),
                FineType = FineType.RedLightViolation,
                CustomerName = "Linda Harris",
                VehicleRegNo = "EFG258",
                VehicleDriverName = "Linda Harris"
            },
            new FinesEntity
            {
                Id = 13,
                FineNo = "F013",
                FineDate = new DateTime(2024, 5, 12),
                FineType = FineType.RedLightViolation,
                CustomerName = "Thomas Clark",
                VehicleRegNo = "HIJ369",
                VehicleDriverName = "Patricia Clark"
            },
            new FinesEntity
            {
                Id = 14,
                FineNo = "F014",
                FineDate = new DateTime(2024, 7, 21),
                FineType = FineType.RedLightViolation,
                CustomerName = "Patricia Walker",
                VehicleRegNo = "KLM741",
                VehicleDriverName = "Patricia Walker"
            },
            new FinesEntity
            {
                Id = 15,
                FineNo = "F015",
                FineDate = new DateTime(2024, 9, 7),
                FineType = FineType.RedLightViolation,
                CustomerName = "Daniel Lewis",
                VehicleRegNo = "NOP852",
                VehicleDriverName = "Daniel Lewis"
            },

            // No Insurance Fines (F016-F020)
            new FinesEntity
            {
                Id = 16,
                FineNo = "F016",
                FineDate = new DateTime(2024, 2, 14),
                FineType = FineType.NoInsurance,
                CustomerName = "Elizabeth Hall",
                VehicleRegNo = "QRS963",
                VehicleDriverName = "Elizabeth Hall"
            },
            new FinesEntity
            {
                Id = 17,
                FineNo = "F017",
                FineDate = new DateTime(2024, 4, 9),
                FineType = FineType.NoInsurance,
                CustomerName = "Matthew Young",
                VehicleRegNo = "TUV159",
                VehicleDriverName = "Matthew Young"
            },
            new FinesEntity
            {
                Id = 18,
                FineNo = "F018",
                FineDate = new DateTime(2024, 6, 18),
                FineType = FineType.NoInsurance,
                CustomerName = "Barbara Allen",
                VehicleRegNo = "WXY267",
                VehicleDriverName = "Steven Allen"
            },
            new FinesEntity
            {
                Id = 19,
                FineNo = "F019",
                FineDate = new DateTime(2024, 8, 26),
                FineType = FineType.NoInsurance,
                CustomerName = "Christopher King",
                VehicleRegNo = "ZAB378",
                VehicleDriverName = "Christopher King"
            },
            new FinesEntity
            {
                Id = 20,
                FineNo = "F020",
                FineDate = new DateTime(2024, 10, 11),
                FineType = FineType.NoInsurance,
                CustomerName = "Susan Moore",
                VehicleRegNo = "CDE489",
                VehicleDriverName = "Susan Moore"
            },

            // Illegal Parking Fines (F021-F025)
            new FinesEntity
            {
                Id = 21,
                FineNo = "F021",
                FineDate = new DateTime(2024, 1, 19),
                FineType = FineType.SeatBeltViolation,
                CustomerName = "Andrew Martin",
                VehicleRegNo = "FGH591",
                VehicleDriverName = "Andrew Martin"
            },
            new FinesEntity
            {
                Id = 22,
                FineNo = "F022",
                FineDate = new DateTime(2024, 3, 27),
                FineType = FineType.SeatBeltViolation,
                CustomerName = "Jessica Taylor",
                VehicleRegNo = "IJK627",
                VehicleDriverName = "Jessica Taylor"
            },
            new FinesEntity
            {
                Id = 23,
                FineNo = "F023",
                FineDate = new DateTime(2024, 5, 5),
                FineType = FineType.SeatBeltViolation,
                CustomerName = "Mark Jackson",
                VehicleRegNo = "LMN738",
                VehicleDriverName = "Emily Jackson"
            },
            new FinesEntity
            {
                Id = 24,
                FineNo = "F024",
                FineDate = new DateTime(2024, 7, 16),
                FineType = FineType.SeatBeltViolation,
                CustomerName = "Emily White",
                VehicleRegNo = "OPQ849",
                VehicleDriverName = "Emily White"
            },
            new FinesEntity
            {
                Id = 25,
                FineNo = "F025",
                FineDate = new DateTime(2024, 9, 23),
                FineType = FineType.SeatBeltViolation,
                CustomerName = "Paul Lopez",
                VehicleRegNo = "RST915",
                VehicleDriverName = "Paul Lopez"
            }
        };
    }
}