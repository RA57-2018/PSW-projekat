export class RecommendAppointmentDto {
    StartInterval: String;
    EndInterval: String;
    DoctorId: number;
    Specialization: number;
    Priority: number;

    constructor(){
        this.StartInterval = "",
        this.EndInterval = "",
        this.DoctorId = 0,
        this.Specialization = 0,
        this.Priority = 0
    }
}