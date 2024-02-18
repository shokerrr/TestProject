SELECT subQ.id, subQ.Sd, subQ.Ed FROM (SELECT d.id as id, d.dt as Sd, dd.dt as Ed, datediff(dd.dt, d.dt) as ddiff FROM dates d LEFT JOIN dates dd ON d.id = dd.id  WHERE d.Dt < dd.Dt
ORDER BY Id, d.Dt, dd.Dt) subQ group by subQ.id, subQ.Sd  having MIN(subQ.ddiff)
