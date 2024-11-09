import api from "./config"

class PollService {
    static ENDPOINTS = {
        BASE: "/polls"
    }

    static async getAllPolls() {
        const response = await api.get(this.ENDPOINTS.BASE);
        return response.data;
    }

    static async createPoll(poll) {
        const response = await api.post(this.ENDPOINTS.BASE, poll);
        return response.data;
    }
}