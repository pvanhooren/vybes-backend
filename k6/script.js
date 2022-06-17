import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        /*{ duration: '2m', target: 100 },
        { duration: '5m', target: 300 },
        { duration: '30s', target: 500 },
        { duration: '2m', target: 200 },
        { duration: '1m', target: 0 }*/
        { duration: '30s', target: 50 },
        { duration: '30s', target: 150 },
        { duration: '10s', target: 250 },
        { duration: '30s', target: 150 },
        { duration: '30s', target: 0 }
    ],
};

export default function () {
    const res = http.get('http://vybes-profile-microservice/all');
    const res2 = http.get('http://vybes-profile-microservice/search/dn/Pim');
    const res3 = http.get('http://vybes-krabbel-microservice/profile');
    const res4 = http.get('http://vybes-krabbel-microservice/profile/pid/with/23');
    
    check(res, { 'status was 200': (r) => r.status == 200 });
    check(res2, { 'status was 200': (r) => r.status == 200 });
    check(res3, { 'status was 200': (r) => r.status == 200 });
    check(res4, { 'status was 200': (r) => r.status == 200 });
    sleep(1);
}