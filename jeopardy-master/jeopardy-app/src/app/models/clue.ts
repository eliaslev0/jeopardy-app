export class Clue {
    id: number | undefined;
    answer?: string;
    question?: string;
    value?: number;
    category?: string;
    airdate?: Date;

    // public int Id { get; set; }
    // public string? Answer { get; set; }
    // public string? Question { get; set; }
    // public int? Value { get; set; }
    // public string? Category { get; set; }
    // public DateOnly? Airdate { get; set; }
}