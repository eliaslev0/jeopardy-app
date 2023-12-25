using System;
using System.Collections.Generic;
using jeopardy.DTO;

namespace jeopardy.EntityModels
{
    public partial class Clue
    {
        public int Id { get; set; }
        public string? Answer { get; set; }
        public string? Question { get; set; }
        public int? Value { get; set; }
        public string? Category { get; set; }
        public DateOnly? Airdate { get; set; }

        public static explicit operator Clue(JeopardyDTO clue) {
            return new Clue() {
                Id = clue.Id,
                Answer = clue.Answer,
                Question = clue.Question,
                Value = clue.Value,
                Category = clue.Category?.Title,
                Airdate = new DateOnly(clue.Airdate.Value.Year, clue.Airdate.Value.Month, clue.Airdate.Value.Day),
            };
            
        }

    }
}